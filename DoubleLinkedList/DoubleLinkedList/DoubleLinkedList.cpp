// DoubleLinkedList.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "iostream"
using namespace std;

struct Node {
    Node* Next;
    Node* Prev;
    int value;
};

void addFront(Node** head, int value)
{
    printf("addFront start, value %d\n\r", value);
    Node* newNode = (Node*)malloc(sizeof(Node));

    if (*head)
    {
        (*head)->Prev = newNode;
    }
    
    newNode->value = value;
    newNode->Next = *head;
    newNode->Prev = NULL;

    *head = newNode;
}


void deleteFront(Node** head)
{
    printf("deleteFront start\n\r");
    //the list could be empty, check if it is
    if (!*head)
    {
        return;
    }

    Node* toDelete = *head;
    *head = toDelete->Next;

    //the new head coud be NULL, check if it is
    if (*head)
    {
        (*head)->Prev = NULL;
    }

    free(toDelete);
}

void printAll(Node* head)
{
    printf("printAll start\n\r");
    Node* item = head;
    while (item)
    {
        printf("Item %d\n\r", item->value);
        item = item->Next;
    }
}

int main()
{
    Node* head = NULL;
    addFront(&head, 1);
    addFront(&head, 2);
    addFront(&head, 3);

    printAll(head);

    deleteFront(&head);
    printAll(head);

    return 0;
}

