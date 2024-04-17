namespace Numerics
{
    public struct Vec2
    {
        public float x;
        public float y;

        public Vec2(float _x, float _y)
        {
            x = _x;
            y = _y;
        }
        public static Vec2 operator +(Vec2 init, Vec2 append)
        {
            Vec2 result = new Vec2(init.x + append.x, init.y + append.y);
            return result;
        }
        public static Vec2 operator -(Vec2 init, Vec2 append)
        {
            Vec2 result = new Vec2(init.x - append.x, init.y - append.y);
            return result;
        }

        public static Vec2 operator *(Vec2 init, int num)
        {
            Vec2 result = new Vec2(init.x * num, init.y * num);
            return result;
        }
        public static Vec2 operator *(Vec2 init, float num)
        {
            Vec2 result = new Vec2(init.x * num, init.y * num);
            return result;
        }

    };
}