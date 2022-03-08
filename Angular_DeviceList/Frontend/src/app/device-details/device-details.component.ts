import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppServiceService } from '../app-service.service';
import { Device } from '../model/Device';

@Component({
  selector: 'app-device-details',
  templateUrl: './device-details.component.html',
  styleUrls: ['./device-details.component.css']
})
export class DeviceDetailsComponent implements OnInit {

  deviceDetail : Device | undefined;

  constructor(private route: ActivatedRoute, private service: AppServiceService) { }

  ngOnInit(): void {
    const deviceId = this.route.snapshot.paramMap.get('id');
    console.log(deviceId);
    this.getDeviceDetailsFromAPI(deviceId);
  }

  getDeviceDetailsFromAPI(id : any){
    this.service.getDeviceByID(id).subscribe((response : Device) => {
      console.log('Response from API is ', response)
      this.deviceDetail = response;
    }, (error) => {
      console.log('Error from API is ', error)
    })
  }
}
