import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {FormControl} from '@angular/forms';
import { PublicationService, PublicationType } from '../../../services/publication.service';
import { ThrottlingExecutor } from 'src/app/shared/throttler';
import {MatDialog, MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import { AddPublicationDialog } from 'src/app/home/dialogs/add-publication/add-publication-type-dialog';
import { filter } from 'rxjs';

@Component({
  selector: 'add-publication',
  templateUrl: './add-publication.component.html',
  styleUrls: ['./add-publication.component.scss']
})
export class AddPublicationComponent implements OnInit {

  public addPublication: FormGroup;
  public loading = false;
  public submitted = false;
  public errorMessage: string;
  public publicationType: string;
  public throttler = new ThrottlingExecutor(300);
  public addPublicationType: string;

  myControl = new FormControl<string | PublicationType>('');
  publicationTypes: PublicationType[] | null;

  constructor(
    private router: Router,
    private publicationService: PublicationService,
    private formBuilder: FormBuilder,
    public dialog: MatDialog
  ) {  }

  public async ngOnInit(): Promise<void> {
    this.publicationTypes = await this.publicationService.getPublicationTypes('');
  }

  displayFn(publicationType: PublicationType): string {
    return publicationType && publicationType.type ? publicationType.type : '';
  }

  public async publicationTypeChange(filter: string) {
    this.throttler.schedule(async () => {
      this.publicationTypes = await this.publicationService.getPublicationTypes(filter);
    });
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddPublicationDialog, {
      data: { publicationType: this.addPublicationType},
    });

    dialogRef.afterClosed().subscribe(async () => {
      this.publicationTypes = await this.publicationService.getPublicationTypes('');
      console.log(this.publicationTypes);
    });
  }

  public async onSubmit(): Promise<void> {

  }
}


