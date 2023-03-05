
namespace Graphic_Engine
{
    public class SemiSpherePizza //This class is in charge of drawing in group both the semi-sphere and the base of it.
    {
        public SemiSpherePizza(int pizzaRadius, int pizzaHeight, int pizzaSlices, float sphereRadius, int numSegments, ref Mesh mesh, bool front)
        {
            Pizza pizza = new Pizza(pizzaRadius, pizzaHeight, pizzaSlices, ref mesh, front);

            HalfSphere halfSphere = new HalfSphere(sphereRadius, numSegments, ref mesh); 
        }
    }
}