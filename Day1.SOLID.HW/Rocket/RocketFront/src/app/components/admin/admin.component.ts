import { Component, OnInit } from '@angular/core';
import { SignalR, SignalRConnection, IConnectionOptions, BroadcastEventListener } from 'ng2-signalr';
import {SnotifyService} from 'ng-snotify';
import { AdminService } from '../../services/admin.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  currTemplate: string;
  pushMsg: string = '';
  users: any;
  roles: any;

  constructor(private _signalR: SignalR, private snotifyService: SnotifyService, private adminService: AdminService)  {

  }

  ngOnInit(){
    this.showTable('1');
  }

  sendPush(){
    if (this.pushMsg.length > 0) {
      let conx = this._signalR.createConnection();
      conx.status.subscribe((s) => console.warn(s.name));
      conx.start().then((c) => {  
        conx.invoke('sendMessage', this.pushMsg).then(() => {
          this.pushMsg = '';
        });
      });
    }    
  }

  showTable(templateId: string){
    this.currTemplate = templateId;

    switch(this.currTemplate) { 
      case '1': { 
         this.adminService.getAllUsers().subscribe(data => {
          this.users = data;
         });
         break; 
      } 
      case '2': { 
        this.adminService.getAllRoles().subscribe(data => {
          this.roles = data;
        });
         break; 
      } 
      case '3': { 
        //statements; 
        break; 
     } 
     case '4': { 
      //statements; 
      break; 
    }       
   } 

  }



}