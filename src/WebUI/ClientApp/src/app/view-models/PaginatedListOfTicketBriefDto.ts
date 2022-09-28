import { TicketBriefDto } from "./TicketBriefDto";

export class PaginatedListOfTicketBriefDto {
  items?: TicketBriefDto[];
  pageNumber?: number;
  totalPages?: number;
  totalCount?: number;
  hasPreviousPage?: boolean;
  hasNextPage?: boolean;
}
