import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Http, Headers, RequestOptions } from '@angular/http';

@Component({
    templateUrl: './contact.list.component.html'
})
export class ContactListComponent {
    public contacts: any[];

    public constructor(private http: Http, private route: ActivatedRoute, private location: Location) {
        this.http.get("/api/contacts/")
            .subscribe(results => {
                this.contacts = results.json() as Contact[];
            }, error => {
                console.error(error);
            });
    } 

    delete(contact: Contact) {
        // A protected click or warning would be smart here.
        this.http.delete('/api/contacts/' + contact.id)
            .subscribe(results => {
                this.contacts.splice(this.contacts.indexOf(contact), 1);
            }, error => {
                console.error(error);
            });
    }

}

interface Contact {
    id: number;
    name: string;
    address: string;
    city: string;
    state: string;
    zip: string;
    email: string;
}