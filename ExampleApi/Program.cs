using System.Collections.Generic;
using HighApi;

Api.Run(new Dictionary<string, object>()
{
    {
        "/", new
        {
            Title = "Simple Title",
            Description = "This is a simple description as a demo."
        }
    }
});
