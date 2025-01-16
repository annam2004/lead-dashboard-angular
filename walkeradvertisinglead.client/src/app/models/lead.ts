export interface Lead {
  id: string; // Guid Unique identifier 
  name: string;
  phoneNumber: string;
  zipCode: string;
  hasEmailPermission: boolean;
  hasTextPermission: boolean;
  email?: string; // Optional field
}
