using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;


//here you have to define the model details : modelName, endpoint, apiKey from the Azure portal

var modelName = "gpt-4.1"; // Model name available in your Azure OpenAI resource
var endpoint = "https://***************.cognitiveservices.azure.com/"; // Your Azure OpenAI endpoint
var apiKey = "**************************************************************************"; // Your Azure OpenAI API key

// Create a kernel with Azure OpenAI chat completion
var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(modelName, endpoint, apiKey);

// Build the kernel
Kernel kernel = builder.Build();
var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

/// Add a plugin (this plugin used when model needs, 
/// like in our case when we create, delete or move directory from one directory to another directory that time is use the plugins.....)
/// same as we can create our own plugins also with different functionalities and complexities.
kernel.Plugins.AddFromType<DirectoryPlugin>("DirectoryManagement");

// Enable planning
OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
{
    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
};

// Create a history store the conversation between user and AI and use that history for future conversation
var history = new ChatHistory();

// Initiate a back-and-forth chat
string? userInput;
do
{
    // Collect user input
    Console.Write("User > ");
    userInput = Console.ReadLine();

    // Add user input
    history.AddUserMessage(userInput);

    // Get the response from the AI
    var result = await chatCompletionService.GetChatMessageContentAsync(
        history,
        executionSettings: openAIPromptExecutionSettings,
        kernel: kernel);

    // Print the results
    Console.WriteLine("Assistant > " + result);

    // Add the message from the agent to the chat history
    history.AddMessage(result.Role, result.Content ?? string.Empty);
} while (userInput is not null);