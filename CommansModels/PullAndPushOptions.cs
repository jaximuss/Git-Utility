using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitUtilityTool.CommansModels
{

    /// <summary>
    /// A CLASS MODEL THAT DEFINES ALL AVAILABLE OPTIONS FOR PULLING AND PUSHING 
    /// IT USES THE VERB <para  name ="Pull-Push"/> to call this options
    /// </summary>
    [Verb("pull-push", HelpText = "Delete branches that have been merged or are stale.")]
    public class PullAndPushOptions
    {
        [Option('p', "pull", Required = false, HelpText = " pull from the remote source if your local isn't up to date")]
        public bool pull { get; set; }

        [Option('s', "push", Required = false, HelpText = "push to your remote source")]
        public bool push { get; set; } 

        [Option('f', "force", Required = false, HelpText = "might remove this option i dont think i need it")]
        public bool Force { get; set; }
    }
}
