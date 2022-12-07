using System;
using System.Collections.Generic;
using System.Text;

namespace PacManv1
{
    class Ghost
    {
        int posX; //row
        int posY; //Column
        bool mode;
        bool isAlive;
        PacManPlayer p1;
        Map map1;
        Map mapforGhost;

        public Ghost(int posX_,int posY_,bool mode_,PacManPlayer p1_, Map map1_, Map mapforGhost_)
        {
            posX = posX_;
            posY = posY_;
            mode = mode_;
            p1 = new PacManPlayer(p1_.GetPosX, p1_.GetPosY, p1_.GetScore, p1_.GetMode,p1_.GetAlive);
            map1 = new Map(map1_.GetMap);
            mapforGhost = new Map(mapforGhost_.GetMap);
            isAlive = true;
        }
        public int GetPosX
        {
            set{ posX = value; }
            get{ return posX; }
        }
        public int GetPosY
        {
            set { posY = value; }
            get { return posY; }
        }
        public bool GetMode
        {
            set { mode = value; }
            get { return mode; }
        }
        public bool GetIsAlive
        {
            set { isAlive = value; }
            get { return isAlive; }
        }
        public PacManPlayer GetPacManPlayer
        {
            set { p1 = value; }
            get { return p1; }
        }
        public Map GetMap
        {
            set { map1 = value; }
            get { return map1; }
        }
        public Map GetMapforGhost
        {
            set { mapforGhost = value; }
            get { return mapforGhost; }
        }

      

        /// <summary>
        /// Modify the ghost map so as to allow the ghost to find the quickest way to get to Pacman
        /// </summary>
        /// <param name="posX">X position (line) of pacman</param>
        /// <param name="posY">Y postion (column) of pacman</param>
        /// <param name="distance">Maximal disctance from the ghost to pacman (60 for map 1)</param>
        /// <param name="started">must be false</param>
        public void RecursivMovementGhost(int posX,int posY,int distance,bool started) // started must be false
        {
            if (started == false)
            {
                mapforGhost.GetMap[posX, posY] = 1;
                started = true;
            }
            if ((mapforGhost.GetMap[posX-1,posY] ==0 || mapforGhost.GetMap[posX - 1, posY]> mapforGhost.GetMap[posX , posY]) && mapforGhost.GetMap[posX, posY] != distance+1)
            {
                mapforGhost.GetMap[posX - 1, posY] = mapforGhost.GetMap[posX, posY] + 1;
                RecursivMovementGhost(posX -1, posY, distance, started);
            }
            if ((mapforGhost.GetMap[posX + 1, posY] == 0 || mapforGhost.GetMap[posX + 1, posY] > mapforGhost.GetMap[posX, posY]) && mapforGhost.GetMap[posX, posY] != distance + 1)
            {
                mapforGhost.GetMap[posX + 1, posY] = mapforGhost.GetMap[posX, posY] + 1;
                RecursivMovementGhost(posX + 1, posY, distance, started);
            }
            if ((posY-1>=0) &&(mapforGhost.GetMap[posX, posY-1] == 0 || mapforGhost.GetMap[posX, posY-1] > mapforGhost.GetMap[posX, posY])&&mapforGhost.GetMap[posX, posY] != distance + 1)
            {
                mapforGhost.GetMap[posX, posY - 1] = mapforGhost.GetMap[posX, posY] + 1;
                RecursivMovementGhost(posX, posY - 1, distance, started);
            }
            if ((posY+1<28)&&(mapforGhost.GetMap[posX, posY + 1] == 0 || mapforGhost.GetMap[posX, posY+1] > mapforGhost.GetMap[posX, posY]) && mapforGhost.GetMap[posX, posY] != distance + 1)
            {
                mapforGhost.GetMap[posX, posY + 1] = mapforGhost.GetMap[posX, posY] + 1;
                RecursivMovementGhost(posX, posY + 1, distance, started);
            }

        }

        /*
        public List<List<string>> ReccurrencePathChoice(List<List<string>> listOfEveryPath, List<string> currentList, bool[] wichIntersectionHasBeenTouched, int distance, string lastMovement,int initialPosX,int initialPosY)
        {
            if (GhostPossibilityToMove("left") == true && lastMovement!="right")
            {
                currentList.Add("left");
                do
                {
                    posY -= 1;
                    distance++;
                    if (mapforGhost.GetMap[posX, posY] == 5)
                    {
                        currentList.Add(Convert.ToString(distance));
                        currentList.Add("TRUE");
                        listOfEveryPath.Add(currentList);
                        return listOfEveryPath;
                    }
                }
                while (GhostPossibilityToMove("up") == false && GhostPossibilityToMove("down") == false);
                if (wichIntersectionHasBeenTouched[mapforGhost.GetMap[posX, posY] - 36] == false)
                {
                    wichIntersectionHasBeenTouched[mapforGhost.GetMap[posX, posY] - 36] = true;
                    ReccurrencePathChoice(listOfEveryPath, currentList, wichIntersectionHasBeenTouched, distance,"left",initialPosX,initialPosY);
                }
                else
                {
                    currentList.Add("-1");
                    currentList.Add("FALSE");
                    listOfEveryPath.Add(currentList);
                    currentList.Clear();
                    posX = initialPosX;
                    posY = initialPosY;
                    return listOfEveryPath;
                }

            }
            if (GhostPossibilityToMove("right") == true && lastMovement != "left")
            {
                currentList.Add("right");
                do
                {
                    posY += 1;
                    distance++;
                    if (mapforGhost.GetMap[posX, posY] == 5)
                    {
                        currentList.Add(Convert.ToString(distance));
                        currentList.Add("TRUE");
                        listOfEveryPath.Add(currentList);
                        return listOfEveryPath;
                    }
                }
                while (GhostPossibilityToMove("up") == false && GhostPossibilityToMove("down") == false);
                if (wichIntersectionHasBeenTouched[mapforGhost.GetMap[posX, posY] - 36] == false)
                {
                    wichIntersectionHasBeenTouched[mapforGhost.GetMap[posX, posY] - 36] = true;
                    ReccurrencePathChoice(listOfEveryPath, currentList, wichIntersectionHasBeenTouched, distance,"right", initialPosX, initialPosY);
                }
                else
                {
                    currentList.Add("-1");
                    currentList.Add("FALSE");
                    listOfEveryPath.Add(currentList);
                    currentList.Clear();
                    posX = initialPosX;
                    posY = initialPosY;
                    return listOfEveryPath;
                }

            }
            if (GhostPossibilityToMove("up") == true && lastMovement != "down")
            {
                currentList.Add("up");
                do
                {
                    posX -= 1;
                    distance++;
                    if (mapforGhost.GetMap[posX, posY] == 5)
                    {
                        currentList.Add(Convert.ToString(distance));
                        currentList.Add("TRUE");
                        listOfEveryPath.Add(currentList);
                        return listOfEveryPath;
                    }
                }
                while (GhostPossibilityToMove("left") == false && GhostPossibilityToMove("right") == false);
                if (wichIntersectionHasBeenTouched[mapforGhost.GetMap[posX, posY] - 36] == false)
                {
                    wichIntersectionHasBeenTouched[mapforGhost.GetMap[posX, posY] - 36] = true;
                    ReccurrencePathChoice(listOfEveryPath, currentList, wichIntersectionHasBeenTouched, distance,"up", initialPosX, initialPosY);
                }
                else
                {
                    currentList.Add("-1");
                    currentList.Add("FALSE");
                    listOfEveryPath.Add(currentList);
                    currentList.Clear();
                    posX = initialPosX;
                    posY = initialPosY;
                    return listOfEveryPath;
                }

            }
            if (GhostPossibilityToMove("down") == true && lastMovement != "up")
            {
                currentList.Add("down");
                do
                {
                    posX += 1;
                    distance++;
                    if(mapforGhost.GetMap[posX,posY]==5)
                    {
                        currentList.Add(Convert.ToString(distance));
                        currentList.Add("TRUE");
                        listOfEveryPath.Add(currentList);
                        return listOfEveryPath;
                    }
                }
                while (GhostPossibilityToMove("left") == false && GhostPossibilityToMove("right") == false);
                if (wichIntersectionHasBeenTouched[mapforGhost.GetMap[posX, posY] - 36] == false)
                {
                    wichIntersectionHasBeenTouched[mapforGhost.GetMap[posX, posY] - 36] = true;
                    ReccurrencePathChoice(listOfEveryPath, currentList, wichIntersectionHasBeenTouched, distance,"down", initialPosX, initialPosY);
                }
                else
                {
                    currentList.Add("-1");
                    currentList.Add("FALSE");
                    listOfEveryPath.Add(currentList);
                    currentList.Clear();
                    posX = initialPosX;
                    posY = initialPosY;
                    return listOfEveryPath;
                }

            }
            return listOfEveryPath;
        }
        */
    }
}
