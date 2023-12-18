﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEyeAssement.DataTransferObject
{
    
       
    public partial class FreeUserTypeDto
        {
            public List<Playlist> Playlists { get; set; }
        }

        public partial class Playlist
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public List<Content> Content { get; set; }
        }

        public partial class Content
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }

