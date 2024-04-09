using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitUtilityTool.CommansModels
{
    /// <summary>
    /// A CLASS MODEL THAT DEFINES ALL AVAILABLE OPTIONS FOR CLEANING UP A BRANCH 
    /// IT USES THE VERB <para  name ="Clean-Branches"/> to call this options
    /// </summary>
    [Verb("clean-branches", HelpText = "Delete branches that have been merged or are stale.")]
    public class CleanBranchesOption
    {
        [Option('m', "merged", Required = false, HelpText = "Delete branches that have been merged into the current branch.")]
        public bool Merged { get; set; }

        [Option('s', "stale", Required = false, HelpText = "Delete branches that are stale (no commits for X days). Specify the number of days.")]
        public int StaleDays { get; set; } = -1; // Using -1 as a default to indicate the option is not set

        [Option('f', "force", Required = false, HelpText = "Delete branches without confirmation.")]
        public bool Force { get; set; }

    }
}
