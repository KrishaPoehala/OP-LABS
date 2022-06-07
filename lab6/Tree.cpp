
#include <iostream>
#include <iomanip>
#include <set>
#include <map>
#include <vector>
#include <queue>
using namespace std;

struct Node
{
	int key;
	Node* left;
	Node* right;
};






void Add(Node*& aBranch, int n)
{
	if (n < 1 || aBranch)
		return;

	aBranch = new Node;
	aBranch->key = n;
	aBranch->left = 0;
	aBranch->right = 0;
	Add(aBranch->right, n - 1);
	Add(aBranch->left, n - 1);

}

void FreeTree(Node* aBranch)
{
	if (!aBranch)
		return;

	FreeTree(aBranch->left);
	FreeTree(aBranch->right);
	delete aBranch;
}

void print(Node* aBranch) {
	if (!aBranch == 0)
	{
		std::cout << aBranch->key << std::endl;
		print(aBranch->right);
		print(aBranch->left);
	}
}

void printLevelOrder(Node* root)
{
	// Base Case
	if (root == NULL) return;

	std::queue<Node*> q;

	q.push(root);

	while (q.empty() == false)
	{
		// nodeCount (queue size) indicates number
		// of nodes at current level.
		int nodeCount = q.size();

		// Dequeue all nodes of current level and
		// Enqueue all nodes of next level
		while (nodeCount > 0)
		{
			Node* node = q.front();
			cout << node->key << " ";
			q.pop();
			if (node->left != NULL)
				q.push(node->left);
			if (node->right != NULL)
				q.push(node->right);
			nodeCount--;
		}
		cout << endl;
	}
}

int main()
{
	Node* Root = 0;
	Add(Root, 5);
	printLevelOrder(Root);
	//print(Root);
	FreeTree(Root);
}
