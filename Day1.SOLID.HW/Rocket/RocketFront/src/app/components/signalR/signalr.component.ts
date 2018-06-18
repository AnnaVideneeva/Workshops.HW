import { Component, OnInit } from '@angular/core';
import { SignalR, SignalRConnection, IConnectionOptions, BroadcastEventListener } from 'ng2-signalr';
import {SnotifyService} from 'ng-snotify';

@Component({
    selector: 'rocket-signalR',
    template: ''
})

export class SignalRComponent implements OnInit {
    
    constructor(private _signalR: SignalR, private snotifyService: SnotifyService) {
    } 
 
    ngOnInit() {
        this.connect();
        this.connectNewRelease();
    }

    connect() {
        let conx = this._signalR.createConnection();
        conx.status.subscribe((s) => console.warn(s.name));
        conx.start().then((c) => {
    
          let listener = c.listenFor('sendMessage');
          listener.subscribe(data => {
              this.snotifyService.simple(data.toString(),"Новое сообщение!");
                  console.log(data);    
          });
        });
      }  

      connectNewRelease() {
        let conx = this._signalR.createConnection();
        conx.status.subscribe((s) => console.warn(s.name));
        conx.start().then((c) => {
    
          let listener = c.listenFor('notifyOfRelease');
          listener.subscribe(data => {
              this.snotifyService.simple(data.toString(),"Новый релиз!");
                  console.log(data);    
          });
        });
      }  

}