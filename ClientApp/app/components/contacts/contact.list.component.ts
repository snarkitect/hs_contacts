import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Http, Headers, RequestOptions } from '@angular/http';

@Component({
    templateUrl: './contact.list.component.html'
})

// TODO: add search and paging functionality for larger contact lists.
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
        // TODO: A protected click or warning would be smart here to prevent accidental deletion.
        this.http.delete('/api/contacts/' + contact.id)
            .subscribe(results => {
                this.contacts.splice(this.contacts.indexOf(contact), 1);
            }, error => {
                console.error(error);
            });
    }

}

// TODO: reorganize the front end model situation so we don't duplicate unnecessary code
interface Contact {
    id: number;
    name: string;
    address: string;
    city: string;
    state: string;
    zip: string;
    email: string;
}