namespace Map
{
    public class RoomState
    {
        public enum State
        {
            Empty,
            Full,
            Open
        }
        
        private MapInstance _mapInstance;
        public State state;
        public State[] directions = new State[4];

        public RoomState()
        {
            state = State.Empty;
            _mapInstance = null;
            for (int i = 0; i < 4; i++)
                directions[i] = State.Empty;
        }

        public void setMapInstance(MapInstance map)
        {
            _mapInstance = map;
            MapInstance.Orientations orientations = _mapInstance.doorsOrientations;
            if (orientations.North)
                directions[0] = State.Open;
            else
                directions[0] = State.Empty;
            
            if (orientations.South)
                directions[1] = State.Open;
            else
                directions[1] = State.Empty;
            
            if (orientations.East)
                directions[2] = State.Open;
            else
                directions[2] = State.Empty;
            
            if (orientations.West)
                directions[3] = State.Open;
            else
                directions[3] = State.Empty;
        }
        
        public MapInstance getMapInstance()
        {
            return _mapInstance;
        }
        
        public RoomState(MapInstance map)
        {
            setMapInstance(map);
            state = State.Open;
        }
    }
}
