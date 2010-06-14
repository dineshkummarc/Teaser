using System.ComponentModel.DataAnnotations;

namespace OpenIdPortableArea.Areas.OpenId.Models
{
    /// <summary>
    ///     LoginInput View Model
    /// </summary>
    public class LoginInput
    {
        /// <summary>
        ///     The Url of the OpenId Provider
        /// </summary>
        [Required]
        public string OpenIdUrl { get; set; }

        public string ReturnUrl { get; set; }
    }
}