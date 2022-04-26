namespace ON.Content.Video.Service.Validators
{
    public class RumbleValidator
    {
        private readonly string[] ValidLanguages;

        public RumbleValidator()
        {
            ValidLanguages =  new string[] { "en", "fr", "es", "jp", "ptbr" };
        }
        //private string[] Errors = new string[14];

        //public async Task<ValidatorResponse> ValidateRequest(RumbleRequest request)
        //{
        //    string[] errors = new string[14];


        //    if (errors.Length > 0)
        //    {
        //        return new ValidatorResponse
        //        {
        //            Errors = errors,
        //            Success = false
        //        };
        //    } else
        //    {
        //        return new ValidatorResponse
        //        {
        //            Success = true,
        //        };
        //    }
        //}

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


    }

    //public class ValidatorResponse
    //{
    //    public bool Success { get; set; } = false;
    //    public string[] Errors { get; set; } = new string[14];
    //}
}
