using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrollViewerDemo1.Entity;

namespace ScrollViewerDemo1.Services
{
    interface IMemberService
    {
        void FormLogin(User member, string api);
        void FormRegister(Member user, string api);
        string FormGetInfo(string api);
    }
}
