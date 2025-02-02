Personal Project Starter Template

This repository is a ready-to-use template for personal projects, offering a robust infrastructure and pre-configured setup for various services. It follows Domain-Driven Design (DDD) principles, ensuring a scalable and maintainable architecture.

🚀 Features

    Domain-Driven Design (DDD) Folder Structure
    A clean and organized folder structure aligned with DDD principles for easier navigation and scalability.

    Dependency Injection
    Fully configured Dependency Injection for seamless service management.

    Pre-configured Services:
        Amazon Cognito: User authentication and authorization.
        Amazon S3: File storage and retrieval.
        Amazon SQS: Queue-based messaging.

    Configurable Startup
    The Startup and Program files are left blank for the user to define their preferred startup logic and configuration.

📂 Project Structure

The repository includes a predefined folder structure for DDD:

📂 Api
📂 Application
📂 DataTransfer
📂 Domain
📂 Infrastructure
📂 Ioc

Each layer is designed to separate responsibilities and ensure better maintainability.

⚙️ Setup

    Clone the repository:
    
git clone repository-url
cd repository-name

Install dependencies:

    dotnet restore  

    Configure the required AWS services (Cognito, S3, SQS) in appsettings.json or environment variables.

    Define your startup logic in Startup.cs or Program.cs.

🛠️ Prerequisites

    .NET 8.0+
    AWS SDK for .NET installed via NuGet

🎯 Use Case

This repository serves as a solid starting point for future personal projects that require robust web services, cloud integrations, and adherence to modern development practices.

📖 Customization

Feel free to adapt and expand this repository to suit your specific needs, whether it's adding new services, modifying configurations, or integrating additional technologies.

🤝 Contributing

Since this repository is intended for personal use, contributions are not currently open. However, feedback and suggestions are always welcome!

📄 License

This repository is licensed under the MIT License.
