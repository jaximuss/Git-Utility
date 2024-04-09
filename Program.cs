using CommandLine;
using GitUtilityTool.CommansModels;
using System.Diagnostics;



// TODO : IMPLEMENT FUNCTIONALITY TO ALL THE METHODS - almost done
// TODO : MAKE A BETTER USER EXPERIENCE - almost done
// TODO : FIX THE OPTIONS PROPERTIES -  i think thats done
// TODO : USE THIS UNTILITY TO PUSH THE PROJECT TO GITHUB - not yet
// TODO : make more options for commiting, addding and adding to a remote branch


public class Program
{
    public static bool conitinue = true;
    public static void Main(string[] args)
    {
        //call intro
        IntroScreen();
        while (conitinue)
        {
            Console.WriteLine("welcome to the git utility tool please input the repository you want to manipulate");
            var repoPath = Console.ReadLine().Trim();

            Console.WriteLine("Available commands: clean-branches,git-ops");
            Console.WriteLine("Please enter the command you want to execute:");
            var commandInput = Console.ReadLine().Trim().ToLower();

            var initOpts = new IntializeGitOptions(); // Initialize appropriately
            var cleanBranchesOpts = new CleanBranchesOption(); // Initialize appropriately

            switch (commandInput)
            {
                case "clean-branches":
                    RunCleanBranchesAndReturnExitCode(cleanBranchesOpts, repoPath);
                    break;
                case "git-ops":
                    Console.WriteLine("here are the options");
                    Console.WriteLine("1.intialize\n 2.remote\n 3.add\n 4.push\n 5.pull\n 6.commit\n 7.status");
                    var answer = Console.ReadLine().Trim().ToLower();
                    if (answer == "intialize")
                    {
                        initOpts.Init = true;
                    }
                    else if (answer == "remote")
                    {
                        initOpts.remote = true;
                    }
                    else if (answer == "add")
                    {
                        initOpts.add = true;
                    }
                    else if (answer == "push")
                    {
                        initOpts.push = true;
                    }
                    else if (answer == "pull")
                    {
                        initOpts.pull = true;
                    }
                    else if (answer == "commit")
                    {
                        initOpts.commit = true;
                    }
                    else if (answer == "status")
                    {
                        initOpts.status = true;
                    }
                    InitializeOptionsAndReturnExitCode(initOpts, repoPath);
                    break;
                default:
                    Console.WriteLine("Command not recognized.");
                    break;
            }

            // Console.WriteLine("would you like to run clean branches and return : Y/N");
            // var answer = Console.ReadLine().Trim().ToUpper();

            //     //PARSE ALL COMMAND LINE INSTRUCTIONS
            //     Parser.Default.ParseArguments<CleanBranchesOption, BatchCommitOption, PullAndPushOptions>(args)
            //.MapResult(
            //        (CleanBranchesOption opts) => RunCleanBranchesAndReturnExitCode(opts, repoPath),
            //        //(BatchCommitOption opts) => RunBatchCommitAndReturnExitCode(opts),
            //        //(PullAndPushOptions opts) => PullAndPushOptionsAndReturnExitCode(opts),
            //        errs => 1); // Handle errors

        }

    }
    private static int InitializeOptionsAndReturnExitCode(IntializeGitOptions opts,string repoPath)
    {
        try
        {
            Loadscreen();
            if (opts.Init)
            {
                var output = ExecuteGitCommand("init", repoPath);
                Console.WriteLine(output); // Outputs the result of the Git command
                YouMustAnswer();
            }
            if (opts.add)
            {
                var output = ExecuteGitCommand("add .", repoPath);
                Console.WriteLine(output); // Outputs the result of the Git command
                YouMustAnswer();
            }
            if (opts.remote)
            {
                Console.WriteLine("please paste the url below");
                var url = Console.ReadLine().Trim();
                var output = ExecuteGitCommand($"remote add origin {url}", repoPath);
                Console.WriteLine(output); // Outputs the result of the Git command
                YouMustAnswer();
            }
            if (opts.push)
            {
                var output = ExecuteGitCommand("push origin master", repoPath);
                Console.WriteLine(output); // Outputs the result of the Git command
                YouMustAnswer();
            }
            if (opts.pull)
            {
                var output = ExecuteGitCommand("pull", repoPath);
                Console.WriteLine(output); // Outputs the result of the Git command
                YouMustAnswer();
            }
            if (opts.commit)
            {
                Console.WriteLine("whats your commit message");
                var message = Console.ReadLine();
                var output = ExecuteGitCommand($"commit -m {message}", repoPath);
                Console.WriteLine(output); // Outputs the result of the Git command
                YouMustAnswer();
            }
            if (opts.status)
            {
                var output = ExecuteGitCommand("status", repoPath);
                Console.WriteLine(output); // Outputs the result of the Git command
                YouMustAnswer();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            YouMustAnswer();
            return 1; // Indicates failure
        }

        return 0; // Indicates success
    }

    private static int PullAndPushOptionsAndReturnExitCode(PullAndPushOptions opts, string repoPath)
    {
        try
        {   
            Console.Write("TRYING TO WORK.");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            var output = ExecuteGitCommand("branch --merged", repoPath);
            Console.WriteLine(output); // Outputs the result of the Git command
                                       // Additional logic to process the output and delete branches as needed
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return 1; // Indicates failure
        }

        return 0; // Indicates success
    }

    private static int RunBatchCommitAndReturnExitCode(BatchCommitOption opts)
    {
        // Placeholder for logic
        Console.WriteLine("Running Batches...");
        return 0; // Success
    }

    private static int RunCleanBranchesAndReturnExitCode(CleanBranchesOption opts, string repoPath)
    {
        // Example of using repoPath with ExecuteGitCommand
        try
        {
            Console.Write("TRYING TO WORK.");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            var output = ExecuteGitCommand("branch --merged", repoPath);
            Console.WriteLine(output); // Outputs the result of the Git command
                                       // Additional logic to process the output and delete branches as needed
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return 1; // Indicates failure
        }

        return 0; // Indicates success
    }

    private static IEnumerable<string> GetMergedBranches(string repoPath)
    {
        var output = ExecuteGitCommand("branch --merged", repoPath);
        return output.Split('\n').Where(line => !string.IsNullOrWhiteSpace(line)).Select(line => line.Trim());
    }

    private static bool ConfirmDeletion(string branch)
    {
        Console.WriteLine($"Delete branch '{branch}'? (y/n)");
        var response = Console.ReadLine();
        return response?.ToLower() == "y";
    }

    private static void DeleteBranch(string branch, bool force, string repoPath)
    {
        ExecuteGitCommand($"branch {(force ? "-D" : "-d")} {branch}", repoPath);
        Console.WriteLine($"Deleted branch '{branch}'.");
    }

    public static string ExecuteGitCommand(string command, string repoPath)
    {
        // Prepare the process start info
        ProcessStartInfo startInfo = new ProcessStartInfo()
        {
            FileName = "git",
            Arguments = command,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
            WorkingDirectory = repoPath
        };

        // Start the process
        using (Process process = new Process())
        {
            process.StartInfo = startInfo;
            process.Start();

            // Read output to string
            string result = process.StandardOutput.ReadToEnd();

            // Wait for the process to finish
            process.WaitForExit();

            // You might also want to check the exit code or standard error to handle errors
            if (process.ExitCode != 0)
            {
                string error = process.StandardError.ReadToEnd();
                throw new InvalidOperationException($"Git command failed with error: {error}");
            }

            return result;
        }
    }

    public static void IntroScreen()
    {
        string asciiArt = @"
  ________.______________  ____ ______________.___.____    .___________________.___.
 /  _____/|   \__    ___/ |    |   \__    ___/|   |    |   |   \__    ___/\__  |   |
/   \  ___|   | |    |    |    |   / |    |   |   |    |   |   | |    |    /   |   |
\    \_\  \   | |    |    |    |  /  |    |   |   |    |___|   | |    |    \____   |
 \______  /___| |____|    |______/   |____|   |___|_______ \___| |____|    / ______|
        \/                                                \/               \/       ";
        Console.WriteLine(asciiArt);
        // Draw the loading bar
        Console.Write("Loading: [");
        int totalBlocks = 30;
        int filledBlocks = 0;
        while (filledBlocks <= totalBlocks)
        {
            int percent = filledBlocks * 100 / totalBlocks;
            Console.Write(new string('=', filledBlocks) + new string(' ', totalBlocks - filledBlocks) + $"] {percent}%\r");
            filledBlocks++;
            Thread.Sleep(100); // Sleep for a short time to simulate loading
        }
    }

    public static void Loadscreen()
    {

        Console.Write("TRYING TO WORK.");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
    }

    public static void YouMustAnswer()
    {
        Console.WriteLine("Do you want to continue operations? : y/n");
        var answer= Console.ReadLine().Trim().ToLower();
        if (answer != null) 
        {
            Console.WriteLine("please you must answer Y/N");
        }
        if (answer == "y")
        {
            conitinue = true;
        }
        if (answer == "n")
        {
           conitinue= false;
        }
    }
}