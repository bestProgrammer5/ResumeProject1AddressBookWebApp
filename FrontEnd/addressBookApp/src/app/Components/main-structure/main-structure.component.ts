import { Component, ElementRef, inject, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { DataVariables } from '../../Dmodel/data-variables';
import { ApiServiceService } from '../../Services/api-service.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-main-structure',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './main-structure.component.html',
  styleUrl: './main-structure.component.css'
})


export class MainStructureComponent implements OnInit {
  @ViewChild('myModal') modal: ElementRef | undefined;

  contactList: DataVariables[] = [];
  contactsService = inject(ApiServiceService);
  contactForm: FormGroup = new FormGroup({});


constructor(private formbuilder: FormBuilder) { }

ngOnInit(): void {
    this.validateInitialFormState();
    this.getContacts();
  }


//Opens bootstrap modal window for adding/updating new contact.
openModal() {
    const modalWindow = document.getElementById('myModal');
    if(modalWindow != null)  {
      modalWindow.style.display = 'block';
    }
}


//Closes bootstrap modal window after adding/updating contact.
closeModal() {
    this.validateInitialFormState();
    if (this.modal != null) {  
      this.modal.nativeElement.style.display = 'none';
    }
}



//Getting all contacts from API
getContacts() {
    this.contactsService.getAllContacts().subscribe((res) => {
      this.contactList = res;
    })
}



//Validates initial form state
validateInitialFormState() {
    this.contactForm = this.formbuilder.group({
          id: [0], 
          firstName: ['', [Validators.required]],
          lastName: ['', [Validators.required]],
          phoneNumber: ['', [Validators.required]],
          emailAddress: ['', [Validators.required]],
        });
} 



//Submits the form
allFieldValues: any;
submitForm()  {
    console.log(this.contactForm.value);
    if(this.contactForm.invalid)  {
      alert('Please fill in all required fields. Thank you!');
      return;
}

//Add and Update part of the code.
if(this.contactForm.value.id == 0)  {  
    
      //Adding a new contact 
      this.allFieldValues = this.contactForm.value;
      this.contactsService.addContact(this.allFieldValues).subscribe((res) => {
        alert('Contact Added Successfully!');
        this.getContacts();
        this.contactForm.reset();
        this.closeModal();
      });

} else  {
      //Update an existing contact
      this.allFieldValues = this.contactForm.value;
      this.contactsService.updateContact(this.allFieldValues).subscribe((res) => {
        alert('Contact Updated Successfully!');
        this.getContacts();
        this.contactForm.reset();
        this.closeModal();
      });
    }
  }


//Edit Method
edit(dataVariables: DataVariables) {
    this.openModal();
    this.contactForm.patchValue(dataVariables);
}


//Remove contact method
remove(dataVariables: DataVariables) { 
    this.contactsService.deleteContact(dataVariables.id).subscribe((res) => {
      alert("Contact deleted successfully!");
      this.getContacts();
    });
}


}