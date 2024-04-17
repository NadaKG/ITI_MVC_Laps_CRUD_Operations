namespace day3.Models
{
    public class CarList
    {
        public static List<Car> Cars = new List<Car>()
        {
            new Car() {  Number=1, Color="Red",   Model="2016" , Manufacturer="Hunda"},
            new Car() {  Number=2, Color="White", Model="2009" ,Manufacturer="BMW"},
            new Car() {  Number=3, Color="Green", Model="2022" ,Manufacturer="COCO"},
            new Car() {  Number=4, Color="Black", Model="2018" ,Manufacturer="Zelda"},
            new Car() {  Number=5, Color="Gray",  Model="2024",Manufacturer="Volkswagen"}
        };
    }
}
