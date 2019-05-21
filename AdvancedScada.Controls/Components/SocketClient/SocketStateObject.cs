using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Net.Sockets;
//******************************************************************************
//* Socket Communication State Object
//*
//* Archie Jacobs
//* Manufacturing Automation, LLC
//* support@advancedhmi.com
//* 20-JAN-18
//*
//* Copyright 2018 Archie Jacobs
//*
//* This class hold data returned from TCP socket communications
//* It's purpose is to accumulate data when all data is not recieved
//*  from a single DataReceived event
//******************************************************************************
namespace AdvancedScada.Controls.Components.SocketClient
{
    public class SocketStateObject
    {

        #region Properties
        private Socket m_workSocket;
        public Socket WorkSocket
        {
            get
            {
                return m_workSocket;
            }
            set
            {
                m_workSocket = value;
            }
        }

        //*********************************
        //* The received data byte stream
        //*********************************
        internal byte[] data = new byte[4096];

        //**********************************
        //* Current Index within data array
        //**********************************
        private int m_CurrentIndex;
        public int CurrentIndex
        {
            get
            {
                return m_CurrentIndex;
            }
            set
            {
                if (value >= data.Length)
                {
                    throw new ArgumentException("TCP State object can only hold up to 4096 bytes");
                    return;
                }
                m_CurrentIndex = value;
            }
        }
        #endregion

        #region Constructors
        public SocketStateObject()
        {
        }

        public SocketStateObject(Socket workSocket)
        {
            m_workSocket = workSocket;
        }
        #endregion

    }
}

