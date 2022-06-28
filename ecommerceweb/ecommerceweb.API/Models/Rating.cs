namespace ecommerceweb.API.Models
{
    public class Rating
    {
        public Guid Id { get; set; }
        public int StarsNumb { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        /*public virtual User User { get; set; }
        public virtual Product Product { get; set; }*/

    }
}
