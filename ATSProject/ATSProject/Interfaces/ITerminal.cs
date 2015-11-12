﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Classes;
namespace ATSProject.Interfaces
{
  public interface ITerminal
    {
      PhoneNumber Number { get; set; }
      string UserName { get; }

      void Call(PhoneNumber target);
     // void IncomingRequestFrom(PhoneNumber source);
      void Drop();
      void Answer();
      void Plug();
      void Unplug();
      void IncomingRequestFrom();

       event EventHandler<PhoneNumber> OutgoingConnection;
       event EventHandler EndCall;
       event EventHandler Plugging;
       event EventHandler UnPlugging;
       event EventHandler IncomingRequest;
       event EventHandler InitAnswer;

    }
}
