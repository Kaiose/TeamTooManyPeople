using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAstar
{
    
    static class Constains
    {
        public const int SIZE = 8;
        public const float STANDARD = 1.0f;
        public const float CROSS = 1.4f;
    }

    public class Node 
    {
        public float x, y;
        public float fcost;
        public float gcost;
        public float hcost;
        public Node Parent;
        public Node[] Child;
        public bool is_in_openlist;
        public bool is_possible;

        public Node()
        {
            x = 0;
            y = 0;
            fcost = 0;
            gcost = 0;
            hcost = 0;
            //Parent = new Node();
            is_in_openlist = false;
            is_possible = true;

        }
        public Node(float x, float y)
        {
            this.x = x;
            this.y = y;
            fcost = 0;
            gcost = 0;
            hcost = 0;
            Parent = null;
            is_in_openlist = false;
            is_possible = true;

        }
        public Node(Node source)
        {
            this.x = source.x;
            this.y = source.y;
            fcost = source.fcost;
            gcost = source.gcost;
            hcost = source.hcost;
            Parent = source.Parent;
            is_in_openlist = source.is_in_openlist;
            is_possible = source.is_possible;
        }
        public void Initialize()
        {
            Child = new Node[Constains.SIZE];

            for (int i = 0; i < Constains.SIZE; i++)
            {
                Child[i] = new Node();
                Child[i].x = x;
                Child[i].y = y;
            }
        }
    }

    public class Astar
    {
        private Node start;
        private Node end;
        private Stack<Node> route;
        private List<Node> closeList;
        private List<Node> openList;
        private int close_index;
        private int open_index;
        
        public Astar(float x, float y, float x2,float y2)
        {
            route = new Stack<Node>();
            closeList = new List<Node>();
            openList = new List<Node>();
            open_index = 0;
            close_index = 0;
            start = new Node(x, y);
            end = new Node(x2, y2);
        }

        float Cal_fcost(Node source, int i)
        {
            return (source.Child[i].hcost + source.Child[i].gcost);
        }


        float Cal_gcost(Node source, int i)
        {
            switch (i)
            {
                case 0:
                    source.Child[i].x -= 1;
                    source.Child[i].y += 1;
                    return source.gcost + Constains.CROSS;

                case 2:
                    source.Child[i].x += 1;
                    source.Child[i].y += 1;
                    return source.gcost + Constains.CROSS;

                case 5:
                    source.Child[i].x -= 1;
                    source.Child[i].y -= 1;
                    return source.gcost + Constains.CROSS;

                case 7:
                    source.Child[i].x += 1;
                    source.Child[i].y -= 1;

                    return source.gcost + Constains.CROSS;
                  
                case 1:
                    source.Child[i].y += 1;
                    return source.gcost + Constains.STANDARD;

                case 3:
                    source.Child[i].x -= 1;
                    return source.gcost + Constains.STANDARD;

                case 4:
                    source.Child[i].x += 1;
                    return source.gcost + Constains.STANDARD;

                case 6:
                    source.Child[i].y -= 1;
                    
                    return source.gcost + Constains.STANDARD;
                    
                default:
                    return -1;
            }
        }

        float Cal_hcost(Node source, int i)
        {
            return Calculate((source.Child[i]), end);
        }

        float Calculate(Node source, Node destination)
        {
            return (float)Math.Sqrt((Math.Pow(destination.x - source.x, 2) + Math.Pow(destination.y - source.y, 2)));
        }

        bool PushOpenlist(Node source)
        {

            //인접 사각형에서 장애물이 있거나 이미 한번 갔던 곳이라면 openlist에 넣지않는다.
            // 그렇기 때문에 이동함수에서 본 source flag 를 true 로 바꿔주는 부분,
            // 인접 사각형 탐색시 장애물이 있다면 child 의 source 를 true로 바꿔준다.

            /*
                지금 내가 c++ 문법에서 짜고 있기 때문에 map table로 검사를 해서 flag 를 변경해줌
                -> 떄문에 class 안에서 미리 맵탐색을 통해 flag를 바꿔주는 부분은 제외해주어도 됨.
                -> c# 으로 옮겨주면서 unity 를 쓸떄 raycast로 Oncollision 으로 flag 를 변경해줘야 함. 
            */
            source.Initialize(); // source의 Child 를 생성해주는 부분
            for (int i = 0; i < Constains.SIZE; i++)
            {
                if (source.Child[i].is_possible == false) continue;

                if (source.Child[i].is_in_openlist == false)
                {//오픈리스트에 들어있지 않다면

                    //fcost gcost hcost 를 계산한다.
                    //gcost와 동시에 좌표까지 계산
                    source.Child[i].gcost = Cal_gcost(source, i);//Child 의 gcost 계산
                    if (source.Child[i].x == 4 && source.Child[i].y == 5) continue;//4,5 를 막아줘봤음
                                                                                     //hcost

                    source.Child[i].hcost = Cal_hcost(source, i);//Child 의 hcost 계산

                    //fcost

                    source.Child[i].fcost = Cal_fcost(source, i); // Child 의 fcost 계산

                    source.Child[i].Parent = source; // Child의 parent Node 설정

                    source.Child[i].is_in_openlist = true;

                    openList.Add(source.Child[i]);
                    open_index++;

                    if (source.Child[i].hcost < 0.4)//원하는값에 근접 
                    {
                        SavePath((source.Child[i]));
                        return true;
                    }

                }
                else
                { // 만약 오픈리스트에 들어있다면
                    float Node_gcost = Cal_gcost(source, i);
                    if(source.Child[i].gcost < Node_gcost)
                    {
                        source.Parent = source.Child[i];
                    }
             
                }
                /*
                    차일드의 부모를 바꿔주는 작업
                */
            }
            return false;
        }

        Node Move(Node source)
        {

            if (open_index == 0) return source;


            int min_index = Find_min();
            source = openList[min_index]; // 우선순위큐에서 가장 낮은 f코스트 값을 빼서 변경
            closeList.Add(source);
            close_index++;
            source.is_possible = false;
            Pop(min_index);
            return source;
        }

        int Find_min()
        {
            Node min = openList[0];
            int min_index = 0;
            for(int i = 0; i < open_index; i++)
            {
                if(min.fcost > openList[i].fcost)
                {
                    min = openList[i];
                    min_index = i;
                }
            }
            return min_index;
        }

        void Pop(int index)
        {
            if (index == open_index - 1) return;

            for(int i = index; i < open_index - 1; i++)
            {
                openList[i] = openList[i + 1];
            }

            open_index--;
        }

        void SavePath(Node source)
        {
            while (source != null)
            {
                route.Push(source);
                source = source.Parent;
            }
        }

        void FollowPath()
        { // 이 부분에서는 유니티가 x,y 를 따라 움직이는 형태로 변해야됨
            while (route.Count != 0)
            {
                Console.WriteLine(route.Peek().x);

                Console.WriteLine(route.Peek().y);
                route.Pop();
            }
        }

        public void Run()
        {
            //기존 노드 push CloseList
            Node source = new Node(start.x,start.y); 
            //souce = start; 하면 어떻게 복사가될까?
            while (true)
            {
                source = Move(source);
                if (PushOpenlist(source)) break;
            }

            FollowPath();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Astar astar = new Astar(1,1 , 3,3);
            astar.Run();

            return;
        }
    }
}
