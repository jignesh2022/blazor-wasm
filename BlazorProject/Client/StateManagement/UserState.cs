using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorProject.Shared;

namespace BlazorProject.Client.StateManagement
{
    //https://wellsb.com/csharp/aspnet/blazor-singleton-pass-data-between-pages/#:~:text=The%20best%20way%20to%20pass%20data%20between%20Blazor,onto%20the%20pages%20or%20components%20that%20need%20it.
    //https://chrissainty.com/3-ways-to-communicate-between-components-in-blazor/
    public class UserState
    {
        public IDictionary<string,object> UserObj { get; private set; }
        public string Token { get; private set; }

        public event Action OnChange;

        public void SetUser(IDictionary<string, object> user)
        {
            UserObj = user;
            NotifyStateChanged();
        }

        public void SetToken(string token)
        {
            Token = token;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
