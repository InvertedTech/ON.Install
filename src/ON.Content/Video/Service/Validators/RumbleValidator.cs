namespace ON.Content.Video.Service.Validators
{
    public class RumbleValidator
    {
        private readonly string[] ValidLanguages;

        public RumbleValidator()
        {
            ValidLanguages =  new string[] { "en", "fr", "es", "jp", "ptbr" };
        }

        public async Task<bool> IsValidLanguageAsync(string language)
        {

            for (int i = 0; i < ValidLanguages.Length; i++)
            {
                if (ValidLanguages[i] == language.ToLower()) { return true; }
            }

            await Task.Delay(1000);

            return false;
        }

        public async Task<bool> IsValidQuery(string query)
        {
            // if (!query.Any(Char.IsWhiteSpace)) 
            // {
            //     return true;
            // }
            // await Task.Delay(500);

            // if (query.Contains("%20%"))
            // {
            //     var tmp = query.Split("%20%");
            //     // TODO: Write functioon to loop over tmp and calculate whether the last 4 chars are %20%
            //     if (tmp[tmp.Length - 1] != "%20%" && tmp[tmp.Length] == "%20%") { return true; }
            // }

            // await Task.Delay(500);
            // return false;

            throw new NotImplementedException();
        }

        public async Task<bool> IsValidNumber(int number, int minRange, int maxRange)
        {
            if (number >= minRange && number <= maxRange) { return true; }

            await Task.Delay(1000);
            return false;
        }

        public async Task<bool> IsValidExtension(string extension)
        {
            if (extension.ToLower() == "json" || extension.ToLower() == "mrss") { return true; }
            
            await Task.Delay(1000);
            return false;
        }

        public async Task<bool> IsValidSort(string sort) 
        { 
            var tmp = sort.ToLower();
            switch (tmp)
            {
                case "date":
                    await Task.Delay(100);
                    return true;
                case "views":
                    await Task.Delay(100);
                    return true;
                case "none":
                    await Task.Delay(100);
                    return true;
                default:
                    await Task.Delay(100);
                    return false;
            }
        }

        public async Task<bool> IsValidMethod(string method) 
        {
            if (method == "Media.Item" || method == "Media.Search") {
                await Task.Delay(1000);
                return true;
            }

            return false;
        }
    }
}
