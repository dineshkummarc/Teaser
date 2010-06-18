using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities.Base;

namespace Teaser.Entities
{
    public class RpxUser : BaseItem
    { 
        public int? SiteUserId { get; set; } 
        public string Identifier { get; set; }
        public string ProviderName { get; set; } 
        public string DisplayName { get; set; }
        public string PreferredUsername { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string UtcOffset { get; set; }
        public string Email { get; set; }
        public string VerifiedEmail { get; set; }

        public string Url { get; set; }
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public string LimitedData { get; set; }
        public string JsonData { get; set; } 

/*
https://rpxnow.com/docs

identifier	 The user's OpenID URL. Use this value to sign the user in to your website. This field is always present.	guaranteed
providerName	 A human-readable name of the authentication provider that was used for this authentication. For well-known providers, Janrain Engage sends values such as "Google", "Facebook", and "MySpace"; "Other" is sent for other providers. New provider names are added over time.	guaranteed
primaryKey	 Primary key of the user in your database. Only present if you are using the mapping API.	guaranteed if a mapping exists
displayName	The name of this Contact, suitable for display to end-users.	Available from most providers, with user consent.
preferredUsername	 The preferred username of this contact on sites that ask for a username.	Available from most providers, with user consent.
name	 A dictionary of name parts. See the name field section for details.	Available from most providers, with user consent.
gender	 The gender of this person. Canonical values are 'male', and 'female', but may be any value.	Available from most providers, with user consent.
birthday	 Date of birth in YYYY-MM-DD format. Year field may be 0000 if unavailable.	Available from most providers, with user consent.
utcOffset	 The offset from UTC of this Contact's current time zone, as of the time this response was returned. The value MUST conform to the offset portion of xs:dateTime, e.g. -08:00. Note that this value MAY change over time due to daylight saving time, and is thus meant to signify only the current value of the user's timezone offset.	Available from most providers, with user consent.
email	An email address at which the person may be reached.	Available from most providers, with user consent. Not available from Twitter, LinkedIn, or MySpace.
verifiedEmail	An email address at which the person may be reached.	Available from Google, Facebook and Yahoo!
url	URL of a webpage relating to this person.	Available from some providers, with user consent.
phoneNumber	A phone number at which the person may be reached.	Available from some providers, with user consent.
photo	URL to a photo (GIF/JPG/PNG) of the person.	Available from some providers, with user consent.
address	 See the address field section for details	Available from some providers, with user consent.
limitedData	true if Janrain Engage was able to retrieve only limited public data from the user's profile (e.g., because the login session has expired or the user logged out from their account). If Janrain Engage succeeded in retrieving complete set of data, this field will be missing or set to false.	Used only with Facebook.
*/

        public RpxUser()
        {
            this.Id = -1;
        } 

    }
}
