FROM mcr.microsoft.com/azure-functions/base:4

# Install Node.js (required by func)
RUN apt-get update && \
    apt-get install -y curl gnupg && \
    curl -sL https://deb.nodesource.com/setup_18.x | bash - && \
    apt-get install -y nodejs

# Install Azure Functions Core Tools v4 (dotnet-isolated compatible)
RUN npm install -g azure-functions-core-tools@4 --unsafe-perm true

WORKDIR /home/site/wwwroot
