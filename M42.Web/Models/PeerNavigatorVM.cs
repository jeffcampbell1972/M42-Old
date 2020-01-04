using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M42.Models
{
    public class PeerNavigatorVM
    {
        public string Identifier { get; set; }
        public string CssClass { get; set; }

        public int NextPeerId { get; set; }
        public string NextPeerLabel { get; set; }

        public int PrevPeerId { get; set; }
        public string PrevPeerLabel { get; set; }

        public int ParentId { get; set; }
        public string ParentLabel { get; set; }

        public string PeerController { get; set; }
        public string PeerAction { get; set; }
        public string PeerArea { get; set; }

        public string ParentController { get; set; }
        public string ParentAction { get; set; }
        public string ParentArea { get; set; }
    }
}