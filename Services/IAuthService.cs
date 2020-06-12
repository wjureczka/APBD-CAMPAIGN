using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_CAMPAIGN.Services
{
    public interface IAuthService
    {
        public AuthTokens GenerateTokens();
    }
}
