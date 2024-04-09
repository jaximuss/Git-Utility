using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitUtilityTool.CommansModels
{
    [Verb("git-ops", HelpText = "initialize git for your projects")]
    public class IntializeGitOptions
    {
        [Option('i', "intialize", Required = false, HelpText = "intialize the repo")]
        public bool Init {  get; set; }

        [Option('r', "remote", Required = false, HelpText = "intialize the repo")]
        public bool remote { get; set; }

        [Option('a', "add", Required = false, HelpText = "intialize the repo")]
        public bool add { get; set; }
     
        [Option('s', "push", Required = false, HelpText = "intialize the repo")]
        public bool push { get; set; }
    
        [Option('P', "pull", Required = false, HelpText = "intialize the repo")]
        public bool pull { get; set; }

        [Option('c', "commit", Required = false, HelpText = "intialize the repo")]
        public bool commit { get; set; }

        [Option('t', "status", Required = false, HelpText = "intialize the repo")]
        public bool status { get; set; }
    }
}
