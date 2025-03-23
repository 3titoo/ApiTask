using Microsoft.AspNetCore.Identity;

namespace ApiTask.identity
{
    /// <summary>
    /// 
    /// </summary>
    public class AppUser : IdentityUser<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public string? PersonName { get; set; }


    }
}
