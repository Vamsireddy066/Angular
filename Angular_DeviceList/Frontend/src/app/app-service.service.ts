import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Device } from './model/Device';

@Injectable({
  providedIn: 'root'
})
export class AppServiceService {

  constructor(private http: HttpClient) { }

  getDevice(){
    return this.http.get<Array<Device>>('api/devices')
  }

  getDeviceByID(deviceId : any){
    return this.http.get<Device>('api/devices/' + deviceId)
  }
}
