import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AccountService, ChangePasswordResponse } from 'src/app/services/account.service';
import { PublicationService } from 'src/app/services/publication.service';

@Component({
  selector: 'app-view-publications',
  templateUrl: './view-publications.html',
  styleUrls: ['./view-publications.scss']
})
export class ViewPublicationsComponent implements OnInit {

  constructor(
    private router: Router,
    private publicationService: PublicationService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {

  }

  public async onSubmit(): Promise<void> {
    
  }
}
