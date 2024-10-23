import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { DataVariables } from '../Dmodel/data-variables';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {

  private mainApiUrl = 'https://localhost:7147/api/Api';

  constructor() { }

  http = inject(HttpClient);


  // ******************* http call methods ********************
getAllContacts() {
    return this.http.get<DataVariables[]>(this.mainApiUrl);
}

addContact(data: any) {
    return this.http.post(this.mainApiUrl, data);
}

updateContact(contact: DataVariables) {
   return this.http.put(`${this.mainApiUrl}/${contact.id}`, contact);
}

deleteContact(id: number) {
    return this.http.delete(`${this.mainApiUrl}/${id}`);
}


}
