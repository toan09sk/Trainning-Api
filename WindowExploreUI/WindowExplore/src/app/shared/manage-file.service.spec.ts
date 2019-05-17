import { TestBed } from '@angular/core/testing';

import { ManageFileService } from './manage-file.service';

describe('ManageFileService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ManageFileService = TestBed.get(ManageFileService);
    expect(service).toBeTruthy();
  });
});
