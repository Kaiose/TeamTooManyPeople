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
	// ������Ͽ� ���Ե� ����ΰ�?
	// ��������̰ų� ��ֹ��� �ִ� ����ΰ�?



public:
	//�����ڿ��� �� Child�� new Ű����� �����Ҵ��ϰԵǸ� ��� �ݺ��ȴ�.
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

		//���� �簢������ ��ֹ��� �ְų� �̹� �ѹ� ���� ���̶�� openlist�� �����ʴ´�.
		// �׷��� ������ �̵��Լ����� �� source flag �� true �� �ٲ��ִ� �κ�,
		// ���� �簢�� Ž���� ��ֹ��� �ִٸ� child �� source �� true�� �ٲ��ش�.

		/*
			���� ���� c++ �������� ¥�� �ֱ� ������ map table�� �˻縦 �ؼ� flag �� ��������
			-> ������ class �ȿ��� �̸� ��Ž���� ���� flag�� �ٲ��ִ� �κ��� �������־ ��.
			-> c# ���� �Ű��ָ鼭 unity �� ���� raycast�� Oncollision ���� flag �� ��������� ��. 
		*/
		source->Initialize(); // source�� Child �� �������ִ� �κ�
		for (int i = 0; i < SIZE; i++) {
			if (source->Child[i].is_possible == false) continue;
			
			if (source->Child[i].is_in_openlist == false) {//���¸���Ʈ�� ������� �ʴٸ�
				
														   //fcost gcost hcost �� ����Ѵ�.
				//gcost�� ���ÿ� ��ǥ���� ���
				source->Child[i].gcost = Cal_gcost(source, i);//Child �� gcost ���
				if (source->Child[i].x == 4 && source->Child[i].y == 5) continue;//4,5 �� ���������
				//hcost
				
				source->Child[i].hcost = Cal_hcost(source,i);//Child �� hcost ���
											 
				//fcost

				source->Child[i].fcost = Cal_fcost(source, i); // Child �� fcost ���
				
				source->Child[i].Parent = source; // Child�� parent Node ����
				
				source->Child[i].is_in_openlist = true;

				openList.push(&(source->Child[i]));  


				if (source->Child[i].hcost < 0.4)//���ϴ°��� ���� 
				{
					SavePath(&(source->Child[i]));
					return true;
				}

			}
			else { // ���� ���¸���Ʈ�� ����ִٸ�
				float Node_gcost = Cal_gcost(source, i);
				source->Child[i].gcost < Node_gcost ? source->Parent = &(source->Child[i]) : NULL;
			}
			/*
				���ϵ��� �θ� �ٲ��ִ� �۾�
			*/
		}
		return false;
	}

	Node* Move(Node* source) {
		
		if (openList.empty()) return source;
		source = openList.top(); // �켱����ť���� ���� ���� f�ڽ�Ʈ ���� ���� ����
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

	void FollowPath() { // �� �κп����� ����Ƽ�� x,y �� ���� �����̴� ���·� ���ؾߵ�
		while (!route.empty()) {
			cout << "x , y : " << route.top()->x << " , " << route.top()->y << endl;
			route.pop();
		}
	}

	void Run() {
		//���� ��� push CloseList
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