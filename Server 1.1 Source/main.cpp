#include <iostream>
#include <WS2tcpip.h>
#include <string>
#include <sstream>
#include <windows.h>
#include <tchar.h>
#include <conio.h>
#include <strsafe.h>



#pragma comment (lib, "ws2_32.lib")
//#pragma comment (lib, "WS2tcpip.lib")

using namespace std;

int main()
{
	BOOL WINAPI SetConsoleTitle(
		_In_ LPCTSTR macara_chat_server
	);

	
	printf("Starting server...\n");
	
	// Initialze winsock
	WSADATA wsData;
	WORD ver = MAKEWORD(2, 2);

	int wsOk = WSAStartup(ver, &wsData);
	if (wsOk != 0)
	{
		cerr << "Can't Initialize winsock! Quitting\n" << endl;
		return 99;
	}
	else {
		//SetConsoleTitle = "Macara Chat Server";
		
		printf("Started winsock...\n");
	}

	// Create a socket
	SOCKET listening = socket(AF_INET, SOCK_STREAM, 0);
	TCHAR szOldTitle[MAX_PATH];
	TCHAR szNewTitle[MAX_PATH];

	// Save current console title.

	if (GetConsoleTitle(szOldTitle, MAX_PATH))
	{
		// Build new console title string.
		std::ostringstream title;
		title << "Macara Online Chat Server (ON PORT: " << listening << ")";
		std::string LtitleText = title.str();
		//SetConsoleTitle(LtitleText.c_str());
		StringCchPrintf(szNewTitle, MAX_PATH, TEXT("Macara Online Chat Server (ON PORT: )"), szOldTitle);

		// Set console title to new title
		if (!SetConsoleTitle(szNewTitle))
		{
			//printf(TEXT("SetConsoleTitle failed (%d)\n"), GetLastError());
			return 1;
		}
		else
		{
			//printf(TEXT("SetConsoleTitle succeeded.\n"));
		}
	}
	if (listening == INVALID_SOCKET)
	{
		cerr << "Can't create a socket! Quitting\n" << endl;
		return 99;
	}
	else {
		fd_set master1;
		FD_ZERO(&master1);

		// Add our first socket that we're interested in interacting with; the listening socket!
		// It's important that this socket is added for our server or else we won't 'hear' incoming
		// connections 
		FD_SET(listening, &master1);
		//FD_CLR(sock, &master1);
		for (u_int i1 = 0; i1 < master1.fd_count; i1++) {
			
			SOCKET outSock1 = master1.fd_array[i1];
			ostringstream portnum;
			portnum << "PORT #: " << outSock1;
			string outNet = portnum.str();
			printf("Listening on valid port...\n");
			
			printf(outNet.c_str(), "\n");
			printf(" \n");
			//printf("PORT #: ")
			
		}
		
		//string portNUM = 80;
		//printf(portNUM);
	}

	// Bind the ip address and port to a socket
	sockaddr_in hint;
	hint.sin_family = AF_INET;
	hint.sin_port = htons(54000);
	hint.sin_addr.S_un.S_addr = INADDR_ANY; // Could also use inet_pton .... 

	bind(listening, (sockaddr*)&hint, sizeof(hint));

	// Tell Winsock the socket is for listening 
	listen(listening, SOMAXCONN);

	// Create the master file descriptor set and zero it
	fd_set master;
	FD_ZERO(&master);

	// Add our first socket that we're interested in interacting with; the listening socket!
	// It's important that this socket is added for our server or else we won't 'hear' incoming
	// connections 
	FD_SET(listening, &master);
	

	// this will be changed by the \quit command (see below, bonus not in video!)
	bool running = true;

	while (running)
	{
		// Make a copy of the master file descriptor set, this is SUPER important because
		// the call to select() is _DESTRUCTIVE_. The copy only contains the sockets that
		// are accepting inbound connection requests OR messages. 

		// E.g. You have a server and it's master file descriptor set contains 5 items;
		// the listening socket and four clients. When you pass this set into select(), 
		// only the sockets that are interacting with the server are returned. Let's say
		// only one client is sending a message at that time. The contents of 'copy' will
		// be one socket. You will have LOST all the other sockets.

		// SO MAKE A COPY OF THE MASTER LIST TO PASS INTO select() !!!

		fd_set copy = master;

		// See who's talking to us
		int socketCount = select(0, &copy, nullptr, nullptr, nullptr);

		// Loop through all the current connections / potential connect
		for (int i = 0; i < socketCount; i++)
		{
			
			// Makes things easy for us doing this assignment
			SOCKET sock = copy.fd_array[i];

			// Is it an inbound communication?
			if (sock == listening)
			{
				
				// Accept a new connection
				SOCKET client = accept(listening, nullptr, nullptr);
				int r = recv(sock, NULL, 0, 0);
				if (r == SOCKET_ERROR && WSAGetLastError() == WSAECONNRESET) {
					// Get the socket number
					SOCKET sockdiscon = master.fd_array[0];
					string msg1 = "SERVER: A user has disconnected from the server.";
					// Send the goodbye message
					send(sockdiscon, msg1.c_str(), msg1.size() + 1, 0);
					//client has disconnected!
				}

				// Add the new connection to the list of connected clients
				FD_SET(client, &master);
				//string sockpr = client;
				//string join = nullptr;
				//printf("joined server: \n" , join);
				//send(client, " Connected to server...\n",size(),  0);

				// Send a welcome message to the connected client
				string welcomeMsg = "SERVER:Welcome to the Chat Server!";
				int sockfd, newsockfd, portno;
				//socklen_t clilen;
				//char buffer[256];
				struct sockaddr_in serv_addr, cli_addr;
				ostringstream clientaddress;
				
				string cadOut = (clientaddress.str(), " Joined the server\n");
				
				//sockfd = socket(AF_INET, SOCK_STREAM, 0);
				//cadOut = ("SERVER: ", cli_addr , " Joined the server");
				//string clientaddr = cli_addr;
				//char buf[4096];
				SOCKET outSocket = master.fd_array[i];
			    //string cadOut = ("%f Joined the server\n", socketCount);

				ostringstream ad;
				//ostringstream joined;

				
				ad << cadOut << "\r\n";
				
				//string clnet = inet_ntop();
				
				string cnetwork = ad.str();
				
				printf(cnetwork.c_str());
				send(client, welcomeMsg.c_str(), welcomeMsg.size() + 1, 0);
				send(outSocket, cnetwork.c_str(), cnetwork.size() + 1, 0);
			}
			else // It's an inbound message
			{
				char buf[4096];
				ZeroMemory(buf, 4096);

				// Receive message
				int bytesIn = recv(sock, buf, 4096, 0);
				//cout << recv;
				
				//std::string recv(int bytes);
				//printf(cin);
				//return 0;

				if (bytesIn <= 0)
				{
					// Drop the client
					closesocket(sock);
					FD_CLR(sock, &master);
				}
				else
				{
					
					// Check to see if it's a command. \quit kills the server
					if (buf[0] == '\\')
					{
						// Is the command quit? 
						string cmd = string(buf, bytesIn);
						if (cmd == "\\quit")
						{
							running = false;
							break;
						}
											
						continue;
					}
					

					// Send message to other clients, and definiately NOT the listening socket

					for (u_int i = 0; i < master.fd_count; i++)
					{
						SOCKET outSock = master.fd_array[i];
						if (outSock == listening)
						{
							continue;
						}

						ostringstream ss;
						//ostringstream joined;

						if (outSock != sock)
						{
							ss << ">>" << buf << "\r\n";
						}
						else
						{
							ss << ">>(ME)" << buf << "\r\n";
						}
						

						string strOut = ss.str();
						
						send(outSock, strOut.c_str(), strOut.size() + 1, 0);
						//printf(" A User Sent Text: \n", strOut.c_str(), strOut.size() + 1, 0);
						string textent = ("\n" ,buf);
						//string beans = (textent.c_str(), "\n");
						printf("\n");
						printf(textent.c_str(), "\n\n");
						
					}
				}
			}
		}
	}

	// Remove the listening socket from the master file descriptor set and close it
	// to prevent anyone else trying to connect.
	FD_CLR(listening, &master);
	closesocket(listening);

	// Message to let users know what's happening.
	string msg = "SERVER:Server is shutting down.\r\n";

	while (master.fd_count > 0)
	{
		// Get the socket number
		SOCKET sock = master.fd_array[0];

		// Send the goodbye message
		send(sock, msg.c_str(), msg.size() + 1, 0);

		// Remove it from the master file list and close the socket
		FD_CLR(sock, &master);
		closesocket(sock);
	}

	// Cleanup winsock
	WSACleanup();

	//system("pause");
	return 0;
}