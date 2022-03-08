import { Component, OnInit } from '@angular/core';
import { AppServiceService } from '../app-service.service';
import { Device } from '../model/Device';


@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html',
  styleUrls: ['./device-list.component.css']
})
export class DeviceListComponent implements OnInit {

  deviceList : Array<Device> = [];
  deviceDetail : Device | undefined;

  constructor(private service: AppServiceService){

  }

  ngOnInit(){
      this.getDeviceFromAPI();
  }

  getDeviceFromAPI(){
      this.service.getDevice().subscribe((response : Array<Device>) => {
        console.log('Response from API is ', response)
        this.deviceList = response;
      }, (error) => {
        console.log('Error from API is ', error)
      })
  }

  getDeviceDetailsFromAPI(id : any){
    this.service.getDeviceByID(id).subscribe((response : Device) => {
      console.log('Response from API is ', response)
      this.deviceDetail = response;
    }, (error) => {
      console.log('Error from API is ', error)
    })
  }

  onSelectedDevice(device : Device){
    console.log('Selected Device ', device);
    this.getDeviceDetailsFromAPI(device.id);
  }
}
