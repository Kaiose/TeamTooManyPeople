#include <iostream>
#include <math.h>
#include <queue>
#include <list>
#include <stack>
using namespace std;

#define SIZE 8
#define STANDARD 1
#define CROSS 1.4f
enum { TopLeft , Top, TopRight, Left, Right, BottomLeft, Bottom, BottomRight};
struct Node {
public:
	float x, y;
	float fcost;
	float gcost;
	float hcost;
	Node* Parent;
	Node* Child;
	bool is_in_openlist;
	bool is_possible;
	// 열린목록에 포함된 노드인가?
	// 닫힌목록이거나 장애물이 있는 노드인가?



public:
	//생성자에서 또 Child를 new 키워드로 동적할당하게되면 계속 반복된다.
	Node():x(0),y(0),fcost(0),gcost(0),hcost(0),Parent(NULL), 
		is_in_openlist(false),is_possible(true){
		
	}
	Node(float x, float y) :x(x), y(y), fcost(0), gcost(0), hcost(0), Parent(NULL)
	, is_in_openlist(false), is_possible(true) {
		
	}

	void Initialize() {
		Child = new Node[SIZE];

		for (int i = 0; i < SIZE; i++) {
			Child[i].x = x;
			Child[i].y = y;
			
		}

	}

};

struct CompareNode{

	bool operator()(Node* a, Node* b) {

		return a->fcost > b->fcost;

	}

};


priority_queue<Node*,vector<Node*>,CompareNode> openList;
list<Node*> closeList;

class Astar {
	Node start;
	Node end;
	stack<Node*> route;
public:

	Astar(float x1,float y1, float x2, float y2):start(x1,y1),end(x2,y2)  {
	}

	float Cal_fcost(Node* source, int i) {
		return (source->Child[i].hcost + source->Child[i].gcost);
	}

	float Cal_gcost(Node* source, int i) {
		switch (i) {
		case 0:
			source->Child[i].x -= 1;
			source->Child[i].y += 1;
			return source->gcost + CROSS;

		case 2:
			source->Child[i].x += 1;
			source->Child[i].y += 1;
			return source->gcost + CROSS;

		case 5:
			source->Child[i].x -= 1;
			source->Child[i].y -= 1;
			return source->gcost + CROSS;

		case 7:
			source->Child[i].x += 1;
			source->Child[i].y -= 1;

			return source->gcost + CROSS;
			break;
		case 1:
			source->Child[i].y += 1;
			return source->gcost + STANDARD;

		case 3:
			source->Child[i].x -= 1;
			return source->gcost + STANDARD;

		case 4:
			source->Child[i].x += 1;
			return source->gcost + STANDARD;

		case 6:
			source->Child[i].y -= 1;

			return source->gcost + STANDARD;
	
		default:
			exit(1);
		}
	}

	float Cal_hcost(Node* source, int i) {
		return Calculate(&(source->Child[i]), &end);
	}

	float Calculate(Node* source, Node* destination) {
		return sqrt(pow(destination->x - source->x, 2) + pow(destination->y - source->y, 2));
	}

	bool PushOpenlist(Node* source) {

		//인접 사각형에서 장애물이 있거나 이미 한번 갔던 곳이라면 openlist에 넣지않는다.
		// 그렇기 때문에 이동함수에서 본 source flag 를 true 로 바꿔주는 부분,
		// 인접 사각형 탐색시 장애물이 있다면 child 의 source 를 true로 바꿔준다.

		/*
			지금 내가 c++ 문법에서 짜고 있기 때문에 map table로 검사를 해서 flag 를 변경해줌
			-> 떄문에 class 안에서 미리 맵탐색을 통해 flag를 바꿔주는 부분은 제외해주어도 됨.
			-> c# 으로 옮겨주면서 unity 를 쓸떄 raycast로 Oncollision 으로 flag 를 변경해줘야 함. 
		*/
		source->Initialize(); // source의 Child 를 생성해주는 부분
		for (int i = 0; i < SIZE; i++) {
			if (source->Child[i].is_possible == false) continue;
			
			if (source->Child[i].is_in_openlist == false) {//오픈리스트에 들어있지 않다면
				
														   //fcost gcost hcost 를 계산한다.
				//gcost와 동시에 좌표까지 계산
				source->Child[i].gcost = Cal_gcost(source, i);//Child 의 gcost 계산
				if (source->Child[i].x == 4 && source->Child[i].y == 5) continue;//4,5 를 막아줘봤음
				//hcost
				
				source->Child[i].hcost = Cal_hcost(source,i);//Child 의 hcost 계산
											 
				//fcost

				source->Child[i].fcost = Cal_fcost(source, i); // Child 의 fcost 계산
				
				source->Child[i].Parent = source; // Child의 parent Node 설정
				
				source->Child[i].is_in_openlist = true;

				openList.push(&(source->Child[i]));  


				if (source->Child[i].hcost < 0.4)//원하는값에 근접 
				{
					SavePath(&(source->Child[i]));
					return true;
				}

			}
			else { // 만약 오픈리스트에 들어있다면
				float Node_gcost = Cal_gcost(source, i);
				source->Child[i].gcost < Node_gcost ? source->Parent = &(source->Child[i]) : NULL;
			}
			/*
				차일드의 부모를 바꿔주는 작업
			*/
		}
		return false;
	}

	Node* Move(Node* source) {
		
		if (openList.empty()) return source;
		source = openList.top(); // 우선순위큐에서 가장 낮은 f코스트 값을 빼서 변경
		closeList.push_back(source);
		source->is_possible = false;
		openList.pop();
		return source;
	}
	void SavePath(Node* source) {
		while (source != nullptr) {
			route.push(source);
			source = source->Parent;
		}
	}

	void FollowPath() { // 이 부분에서는 유니티가 x,y 를 따라 움직이는 형태로 변해야됨
		while (!route.empty()) {
			cout << "x , y : " << route.top()->x << " , " << route.top()->y << endl;
			route.pop();
		}
	}

	void Run() {
		//기존 노드 push CloseList
		Node* source = &start;
		
		while (true) {
			source = Move(source);
			if (PushOpenlist(source)) break;
		}

		FollowPath();
	}
};

int main() {
	Astar astar(1,1 ,4,7 );

	astar.Run();

	return 0;
}