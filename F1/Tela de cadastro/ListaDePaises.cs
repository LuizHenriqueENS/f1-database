namespace F1 {
    internal class ListaDePaises {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Iso3 { get; set; }
        public int NumericCode { get; set; }
        public string Capital { get; set; }
        public string Currency { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public string Tld { get; set; }
        public string Native { get; set; }
        public string Region { get; set; }
        public string SubRegion { get; set; }
        public string TimeZones { get; set; }
        public string Translations { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Emoji { get; set; }
        public string EmojiU { get; set; }

        public ListaDePaises() {
        }

        public ListaDePaises(int id, string name, string iso3, int numericCode, string capital, string currency, string currencyName, string currencySymbol, string tld, string native, string region, string subRegion, string timeZones, string translations, string latitude, string longitude, string emoji, string emojiU) {
            Id = id;
            Name = name;
            Iso3 = iso3;
            NumericCode = numericCode;
            Capital = capital;
            Currency = currency;
            CurrencyName = currencyName;
            CurrencySymbol = currencySymbol;
            Tld = tld;
            Native = native;
            Region = region;
            SubRegion = subRegion;
            TimeZones = timeZones;
            Translations = translations;
            Latitude = latitude;
            Longitude = longitude;
            Emoji = emoji;
            EmojiU = emojiU;
        }
    }

}
