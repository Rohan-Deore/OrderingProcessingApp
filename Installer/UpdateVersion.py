from lxml import etree
import os

def update_version_prefix(csproj_files, version_file):
    # Read the version from version.txt
    with open(version_file, 'r') as vf:
        version = vf.read().strip()

    for csproj_file in csproj_files:
        # Parse the .csproj file
        parser = etree.XMLParser(remove_blank_text=True)
        tree = etree.parse(csproj_file, parser)
        root = tree.getroot()

        # Define the namespace
        namespace = {'msbuild': 'http://schemas.microsoft.com/developer/msbuild/2003'}

        # Find the VersionPrefix element and update its value
        property_group = root.find('PropertyGroup')
        if property_group is None:
            print('Missing property group')
            return
        
        version_prefix = property_group.find('VersionPrefix')
        if version_prefix is not None:
            version_prefix.text = version
        else:
            # If VersionPrefix doesn't exist, create it
            property_group = root.find('PropertyGroup')
            if property_group is None:
                property_group = etree.SubElement(root, 'PropertyGroup')
            version_prefix = etree.SubElement(property_group, 'VersionPrefix')
            version_prefix.text = version

        # Write the updated .csproj file back to disk
        tree.write(csproj_file, pretty_print=True, xml_declaration=False, encoding='utf-8')

def find_csproj_files(root_dir):
    csproj_files = []
    for subdir, _, files in os.walk(root_dir):
        for file in files:
            if file.endswith('.csproj'):
                csproj_files.append(os.path.join(subdir, file))
    return csproj_files

if __name__ == "__main__":
    root_directory = 'D:/Code/Samples/OrderProcessingApp'
    version_file = 'Version.txt'
    csproj_files = find_csproj_files(root_directory)
    update_version_prefix(csproj_files, version_file)
    print('Versions updated.')
