# 📂 Semantic Kernel Directory Management Plugin  

This repository demonstrates how to use **[Microsoft Semantic Kernel](https://github.com/microsoft/semantic-kernel)** with **Azure OpenAI** to create a conversational AI agent that can also manage your local file system.  

It includes a **custom plugin (`DirectoryPlugin`)** that provides functionality for:  
- Creating and deleting directories  
- Creating, updating, reading, and deleting files  

The AI model (powered by **Azure OpenAI ChatCompletion**) can call these plugin functions automatically when the conversation context requires it.  

---

## 🚀 Features  

- ✅ Chat-based interaction with Azure OpenAI models  
- ✅ Automatic function calling via Semantic Kernel planning  
- ✅ Directory operations (create / delete)  
- ✅ File operations (create / update / delete / read)  
- ✅ Extendable plugin system for additional functionality  

---

## 📦 Project Structure  

```plaintext
.
├── Program.cs              # Entry point: sets up Semantic Kernel, chat loop, and plugins
├── DirectoryPlugin.cs      # Custom plugin with directory and file management methods
├── semantickernelPractice  # Namespace for organizing the code
```

---

## 🛠️ Setup Instructions  

### 1. Clone the repository  
```bash
git clone https://github.com/your-username/semantic-kernel-directory-plugin.git
cd semantic-kernel-directory-plugin
```

### 2. Install dependencies  
Make sure you’re using **.NET 8.0 or later**.  
```bash
dotnet restore
```

### 3. Configure Azure OpenAI  
Replace the placeholders in **`Program.cs`** with your actual Azure OpenAI details:  

```csharp
var modelName = "gpt-4.1"; // Your model deployment name
var endpoint = "https://<your-resource-name>.cognitiveservices.azure.com/";
var apiKey = "<your-api-key>";
```

> 🔑 You can find these values in the [Azure OpenAI portal](https://portal.azure.com/).

### 4. Run the application  
```bash
dotnet run
```

You’ll get a chat prompt:  

```plaintext
User > 
```

Now you can chat with the AI and ask it to manage directories/files.  

---

## 💻 Example Usage  

### Create a directory  
```plaintext
User > Create a directory at C:\Temp\TestFolder
Assistant > ✅ Directory created: C:\Temp\TestFolder
```

### Create a file  
```plaintext
User > Create a file at C:\Temp\TestFolder\hello.txt with content "Hello, World!"
Assistant > 📄 File created/updated: C:\Temp\TestFolder\hello.txt
```

### Read a file  
```plaintext
User > Read the file at C:\Temp\TestFolder\hello.txt
Assistant > 📖 File content of C:\Temp\TestFolder\hello.txt:
Hello, World!
```

### Delete a file  
```plaintext
User > Delete the file at C:\Temp\TestFolder\hello.txt
Assistant > 🗑️ File deleted: C:\Temp\TestFolder\hello.txt
```

### Delete a directory  
```plaintext
User > Delete the directory at C:\Temp\TestFolder
Assistant > 🗑️ Directory deleted: C:\Temp\TestFolder
```

---

## 🧩 DirectoryPlugin Overview  

The **`DirectoryPlugin`** provides the following functions:  

- `CreateDirectoryAsync(path)` → Creates a new directory.  
- `DeleteDirectoryAsync(path)` → Deletes a directory and its contents.  
- `CreateOrUpdateFileAsync(filePath, content)` → Creates or updates a file with content.  
- `DeleteFileAsync(filePath)` → Deletes a file.  
- `ReadFileAsync(filePath)` → Reads and returns the file content.  

Each method is decorated with `[KernelFunction]` so that Semantic Kernel can expose it to the AI model.  

---

## ⚠️ Important Notes  

- These operations **directly modify your file system**. Use with caution.  
- Always run in a **safe environment** when testing.  
- The AI model will choose to call plugin functions automatically when relevant.  

---

## 📚 Resources  

- [Microsoft Semantic Kernel Documentation](https://learn.microsoft.com/en-us/semantic-kernel/overview/)  
- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/cognitive-services/openai/)  

---

## 📄 License  

This project is licensed under the **MIT License** – feel free to use, modify, and share.  
