# Git Utility Tool

The Git Utility Tool is a command-line application designed to simplify and automate common Git operations. This tool allows users to perform tasks such as cleaning up merged or stale branches, initializing new repositories, managing remotes, and more, all from the convenience of a single command-line interface.

## Features

- Clean up branches that have been merged or are stale.
- Initialize new Git repositories.
- Add and manage remote repositories.
- Stage, commit, push, and pull changes.
- Check the status of the repository.

## Installation

1. Ensure you have [Git installed](https://git-scm.com/downloads) on your machine.
2. Clone this repository to your local machine using Git:
git clone https://github.com/jaximuss/Git-Utility.git
3. Navigate into the cloned directory:
`cd git-utility-tool`
4. Compile the project (ensure you have [.NET SDK](https://dotnet.microsoft.com/download) installed):
dotnet build



## Usage

Run the tool from the command line within the project's directory:

`dotnet run`



Follow the on-screen prompts to select the repository you wish to manipulate and the operation you want to perform.

### Examples

- To clean up merged branches:
Please enter the command you want to execute:
clean-branches


- To initialize a new Git repository:
Please enter the command you want to execute:
git-ops
here are the options:
1.initialize

initialize

## Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

Distributed under the MIT License. See `LICENSE` for more information.
