﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_CAMPAIGN.DTO.Responses
{
    public class RefreshTokenResponse
    {
        public string AccessToken { get; set; }
     
        public string RefreshToken { get; set; }
    }
}
