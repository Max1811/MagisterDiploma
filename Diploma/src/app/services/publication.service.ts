import { Injectable } from '@angular/core';
import { ApiClient } from './api.client';

@Injectable({
    providedIn:'root'
})

export class PublicationService {
  constructor(private api: ApiClient) { }

  public getPublicationTypes(filter: string): Promise<PublicationType[] | null> {
    var url = 'publication/publication-types';

    if (filter && filter != '')
      url += `?filter=${filter}`;

    return this.api.get(url);
  }

  public addPublicationType(publicationType: string) {
    return this.api.post('publication/publication-type', { publicationType: publicationType });
  }
}

export interface PublicationType {
  id: number;
  type: string;
}

