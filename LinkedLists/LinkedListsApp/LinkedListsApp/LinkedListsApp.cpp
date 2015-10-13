// LinkedListsApp.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

struct Node {
    Node* Next;
    int data;
};

void Add_Front(Node** head, int data)
{
    printf("Add_Front %d\n\r", data);
    Node* newNode = (Node*)malloc(sizeof(Node));

    newNode->Next = *head;
    newNode->data = data;

    *head = newNode;
}

void Delete_Front(Node** head)
{
    printf("Delete_Front\n\r");
    if (!*head)
    {
        return;
    }

    Node* next = (*head)->Next;
    free(*head);
    *head = next;
}

void Delete_All(Node** head)
{
    printf("Delete_All\n\r");
    while (*head)
    {
        Delete_Front(head);
    }

}

void Print_All(Node* head)
{
    printf("Print_All\n\r");
    Node* elem = head;
    while (elem)
    {
        printf("item %d\r\n", elem->data);
        elem = elem->Next;
    }
}


void Print_Recursive(Node* elem)
{
    if (!elem)
    {
        return;
    }

    printf("item %d\r\n", elem->data);
    Print_Recursive(elem->Next);
}

void Delete(Node** head, int data)
{
    Node* prev = NULL;
    Node* elem = *head;

    while (elem)
    {
        if (elem->data == data)
        {
            //if prev == NULL then elem has not moved and this is the head
            //move head to next (which could be null)
            if (!prev)
            {
                *head = (*head)->Next;
            }
            else
            {
                prev->Next = elem->Next;
            }

            //we found the element, free up the memory and return;
            free(elem);
            return;
        }
        prev = elem;
        elem = elem->Next;
    }
}

int main()
{
    //cout << "Hi!";
    Node* head;
    head = NULL;

    Delete(&head, 2);

    Add_Front(&head, 3);
    Add_Front(&head, 4);
    Add_Front(&head, 5);
/*
    Print_All(head);

    Print_Recursive(head);

    Delete(&head, 2);
    Delete(&head, 4);
    Print_All(head);

    Add_Front(&head, 6);
    Add_Front(&head, 7);

    Print_All(head);

    Delete_Front(&head);
    Print_All(head);*/
    Print_All(head);

    Delete_All(&head);
    Print_All(head);

    Delete_All(&head);
    return 0;
}