using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Patika.Dto.ViewModel;
using System.Text;

namespace Patika.Utils.Helpers
{
    public class SessionHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public SessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserViewModel GetUserViewModel()
        {
            var sessionByte = default(byte[]);
            _session.TryGetValue("patikaUserSession", out sessionByte);

            return JsonConvert.DeserializeObject<UserViewModel>(sessionByte.ToString());
        }
        public void SetUserViewModel(UserViewModel userViewModel)
        {
            _session.Set("patikaUserSession", Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(userViewModel)));
            
        }
    }
}