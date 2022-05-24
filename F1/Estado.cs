namespace F1 {
    class Estado {

        public int ID { get; set; }
        public string Name { get; set; }
        public int Country_Id { get; set; }
        public string Country_Code { get; set; }
        public string ISO2 { get; set; }



        public Estado(int iD, string name, int country_Id, string country_Code, string iSO2) {
            ID = iD;
            Name = name;
            Country_Id = country_Id;
            Country_Code = country_Code;
            ISO2 = iSO2;
        }

        public Estado() {
        }
    }
}
