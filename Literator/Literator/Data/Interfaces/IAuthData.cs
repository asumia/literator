using Literator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data.Interfaces
{
    public interface IAuthData
    {
        void createAuthData(AuthorizationData data);
    }
}
