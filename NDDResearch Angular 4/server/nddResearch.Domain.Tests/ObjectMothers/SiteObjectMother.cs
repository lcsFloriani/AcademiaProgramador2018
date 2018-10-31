using NDDResearch.Domain.Features.Sites;

namespace nddResearch.Domain.Tests.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static class SiteObjectMother
        {
            public static Site Default
            {
                get
                {
                    var customer = CustomerObjectMother.Default;
                    return new Site
                    {
                        Name = "Novo Site Default",
                        NationalIdNumber = "00000000002",
                        IsDefault = false,
                    };
                }
            }
        }
    }
}
